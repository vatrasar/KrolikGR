---
trigger: manual
description: use it when user ask you to create skill for ai agent
---

Skill Locations:
Depending on the user's needs, prepare the folder structure for one of these locations:

Workspace-specific: <workspace-root>/.agents/skills/<skill-folder-name>/ (Best for project-specific workflows).

Folder Structure:
The SKILL.md file is the only required file. You can also design optional subdirectories:

scripts/ – helper scripts.

examples/ – reference implementations.

resources/ – templates and other assets.

Requirements for the SKILL.md file:
Every SKILL.md file MUST start with a YAML frontmatter block:

YAML
---
name: [unique-skill-name]
description: [clear-description-of-what-the-skill-does]
---
* name: (Optional) A unique identifier using lowercase and hyphens. If omitted, the system defaults to the folder name.

* description: (Required) This is critical. The agent uses this during the "Discovery" phase to decide if the skill is relevant. Rule: Write the description in the third person and include keywords (e.g., "Generates unit tests for Python code using pytest conventions").

Below the YAML header, include detailed instructions formatted in Markdown (e.g., ## When to use this skill, ## How to use it, step-by-step guides, and patterns).

Best Practices:

Keep skills focused: Each skill should do one thing well. Create separate skills for distinct tasks instead of one "do-everything" skill.

Scripts as black boxes: If the skill includes scripts, instruct the agent to run them with --help first rather than reading the entire source code to keep the context focused.

Include decision trees: For complex skills, add a section to help the agent choose the right approach based on the situation.